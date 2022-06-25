import React, { useState, useCallback, useRef } from "react";
import {
  GoogleMap,
  useLoadScript,
  Marker,
  InfoWindow,
} from "@react-google-maps/api";
import { formatRelative } from "date-fns";
import GeoLocation from "./GeoLocation";

const libraries = ["places"];
const mapContainerStyle = {
  height: "100vh",
  width: "100vw",
};
const options = {
  disableDefaultUI: true,
  zoomControl: true,
};
const center = {
  lat: 47.62,
  lng: -122.34,
};

export default function Map() {
  const { isLoaded, loadError } = useLoadScript({
    googleMapsApiKey: process.env.REACT_APP_GOOGLE_MAPS_API_KEY,
    libraries,
  });

  const [russianTroops, setRussianTroops] = useState([]);
  const [russianTroopDetails, setRussianTroopDetails] = useState(null);

  const onMapClick = useCallback((e) => {
    setRussianTroops((current) => [
      ...current,
      {
        lat: e.latLng.lat(),
        lng: e.latLng.lng(),
        time: new Date(),
      },
    ]);
  }, []);

  const mapRef = useRef();
  const onMapLoad = useCallback((map) => {
    mapRef.current = map;
  }, []);

  const panTo = useCallback(({ lat, lng }) => {
    mapRef.current.panTo({ lat, lng });
    mapRef.current.setZoom(14);
  }, []);

  if (loadError) return "Error";
  if (!isLoaded) return "Loading...";

  return (
    <div>
      <GeoLocation panTo={panTo} />
      <GoogleMap
        id="map"
        mapContainerStyle={mapContainerStyle}
        zoom={18}
        center={center}
        options={options}
        onLoad={onMapLoad}
        onClick={onMapClick}
      >
        {russianTroops.map((troop) => (
          <Marker
            key={`${troop.lat}-${troop.lng}`}
            position={{ lat: troop.lat, lng: troop.lng }}
            onClick={() => {
                setRussianTroopDetails(troop);
            }}
            icon={{
              url: `/rusFlag.png`,
              origin: new window.google.maps.Point(0, 0),
              anchor: new window.google.maps.Point(15, 15),
              scaledSize: new window.google.maps.Size(30, 30),
            }}
          />
        ))}

        {russianTroopDetails ? (
          <InfoWindow
            position={{ lat: russianTroopDetails.lat, lng: russianTroopDetails.lng }}
            onCloseClick={() => {
              setRussianTroopDetails(null);
            }}
          >
            <div>
              <h2>
                Careful! Troop was spotted here
              </h2>
              <p>Spotted {formatRelative(russianTroopDetails.time, new Date())}</p>
            </div>
          </InfoWindow>
        ) : (
          null
        )}
      </GoogleMap>
    </div>
  );
}
