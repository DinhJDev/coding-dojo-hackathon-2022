import React from "react";
import {
  GoogleMap,
  useLoadScript,
  Marker,
  InfoWindow,
} from "@react-google-maps/api";
import { formatRelative } from "date-fns";

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

  const [russianTroops, setRussianTroops] = React.useState([]);
  const [russianTroopDetails, setRussianTroopDetails] = React.useState(null);

  const onMapClick = React.useCallback((e) => {
    setRussianTroops((current) => [
      ...current,
      {
        lat: e.latLng.lat(),
        lng: e.latLng.lng(),
        time: new Date(),
      },
    ]);
  }, []);

  const mapRef = React.useRef();
  const onMapLoad = React.useCallback((map) => {
    mapRef.current = map;
  }, []);

  if (loadError) return "Error";
  if (!isLoaded) return "Loading...";

  return (
    <div>
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
