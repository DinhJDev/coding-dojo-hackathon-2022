import React, { useEffect, useState, useCallback, useRef } from "react";
import {
  GoogleMap,
  useLoadScript,
  Marker,
  InfoWindow,
} from "@react-google-maps/api";
import moment from 'moment';
import { formatRelative } from "date-fns";
import GeoLocation from "./GeoLocation";

import MapContext from "./MapContext";

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

export default function Map({ page }) {
  const { isLoaded, loadError } = useLoadScript({
    googleMapsApiKey: process.env.REACT_APP_GOOGLE_MAPS_API_KEY,
    libraries,
  });

  // Troop
  const [russianTroops, setRussianTroops] = useState([]);
  const [russianTroopDetails, setRussianTroopDetails] = useState(null);

  // Supplies
  const [supplies, setSupplies] = useState([]);
  const [suppliesDetail, setSuppliesDetail] = useState(null);

  const [filteredData, setFilteredData] = useState({});

  const onMapClickTroops = useCallback((e) => {
    setRussianTroops((current) => [
      ...current,
      {
        lat: e.latLng.lat(),
        lng: e.latLng.lng(),
        time: moment(new Date()).format(),
      },
    ]);
  }, []);

  const onMapClickSupplies = useCallback((e) => {
    setSupplies((current) => [
      ...current,
      {
        lat: e.latLng.lat(),
        lng: e.latLng.lng(),
        time: moment(new Date()).format(),
      },
    ]);
  }, []);

  const id = 2

  const getTroops = (id) => {
    fetch(`https://localhost:7032/api/Zone?id=${id}`)
      .then(response => response.json())
      .then(data => setFilteredData(data))
  }


  const sendTroopInfo = (russianTroops) => {
    fetch(`https://localhost:7032/api/Zone`, {
      method: "POST",
      headers: {
        body: JSON.stringify(russianTroops)
      }
    })
      .then((response) => response.json())
      .then((result) => { console.log(result) })
  }

  useEffect(() => {
    getTroops(id)
    sendTroopInfo(russianTroops)
  }, [id, russianTroops])

  // console.log(filteredData)
  console.log(russianTroops)

  const mapRef = useRef();
  const onMapLoad = useCallback((map) => {
    mapRef.current = map;
  }, []);

  const panTo = useCallback(({ lat, lng }) => {
    mapRef.current.panTo({ lat, lng });
    mapRef.current.setZoom(18);
  }, []);

  let itemShownPlacer = onMapClickTroops

  if (page === '2') {
    itemShownPlacer = onMapClickSupplies
  } else {
    itemShownPlacer = itemShownPlacer
  }


  if (loadError) return "Error";
  if (!isLoaded) return "Loading...";



  const state = {

  };

  return (
    <MapContext.Provider value={state}>
      <div>
        <GeoLocation panTo={panTo} />
        <GoogleMap
          id="map"
          mapContainerStyle={mapContainerStyle}
          zoom={18}
          center={center}
          options={options}
          onLoad={onMapLoad}
          onClick={itemShownPlacer}
        >
          {page === '1' && (
            <div>
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
                  position={{
                    lat: russianTroopDetails.lat,
                    lng: russianTroopDetails.lng,
                  }}
                  onCloseClick={() => {
                    setRussianTroopDetails(null);
                  }}
                >
                  <div>
                    <h2>Careful! Troop was spotted here</h2>
                    <p>
                      Spotted{" "}
                      {moment().startOf(new Date()).fromNow()}
                    </p>
                  </div>
                </InfoWindow>
              ) : null}
            </div>
          )}

          {page === '2' && (
            <div>
              {supplies.map((troop) => (
                <Marker
                  key={`${troop.lat}-${troop.lng}`}
                  position={{ lat: troop.lat, lng: troop.lng }}
                  onClick={() => {
                    setSuppliesDetail(troop);
                  }}
                  icon={{
                    url: `/package.svg`,
                    origin: new window.google.maps.Point(0, 0),
                    anchor: new window.google.maps.Point(15, 15),
                    scaledSize: new window.google.maps.Size(30, 30),
                  }}
                />
              ))}

              {suppliesDetail ? (
                <InfoWindow
                  position={{
                    lat: suppliesDetail.lat,
                    lng: suppliesDetail.lng,
                  }}
                  onCloseClick={() => {
                    setSuppliesDetail(null);
                  }}
                >
                  <div>
                    <h2>Supply Here</h2>
                    <p>
                      Spotted{" "}
                      {moment().startOf(new Date()).fromNow()}
                      {/* {formatRelative(suppliesDetail.time, new Date())} */}
                      { }
                    </p>
                  </div>
                </InfoWindow>
              ) : null}
            </div>
          )}
        </GoogleMap>
      </div>
    </MapContext.Provider>
  );
}
