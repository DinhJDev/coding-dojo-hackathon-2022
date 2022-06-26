import React, { useEffect, useState, useCallback, useRef } from "react";
import {
  GoogleMap,
  useLoadScript,
  Marker,
  InfoWindow,
} from "@react-google-maps/api";
import { formatRelative } from "date-fns";
import GeoLocation from "./GeoLocation";
import moment from 'moment';

const libraries = ["places"];
const mapContainerStyle = {
  height: "100vh",
  width: "100vw",
};
const options = {
  mapId: "c16a70408e094259",
  disableDefaultUI: true,
  zoomControl: true,
};
const center = {
  lat: 47.62,
  lng: -122.34,
};

export default function Map({ page }) {
  const time = new Date()
  const { isLoaded, loadError } = useLoadScript({
    googleMapsApiKey: process.env.REACT_APP_GOOGLE_MAPS_API_KEY,
    libraries,
  });

  // Troop
  const [russianTroops, setRussianTroops] = useState([]);
  const [russianTroopDetails, setRussianTroopDetails] = useState(null);

  const [troopData, setTroopData] = useState([]);

  const onMapClickTroops = useCallback((e) => {
    setRussianTroops((current) => [
      ...current,
      {
        lat: e.latLng.lat(),
        lng: e.latLng.lng(),
      },
    ]);
  }, []);

  const sendTroopInfo = (russianTroops) => {
    if (russianTroops.length > 0) {
      var myHeaders = new Headers();
      myHeaders.append("Content-Type", "application/json");

      var raw = JSON.stringify({
        "lat": `${russianTroops[russianTroops.length - 1]?.lat}`,
        "lng": `${russianTroops[russianTroops.length - 1]?.lng}`
      });

      var requestOptions = {
        method: 'POST',
        headers: myHeaders,
        body: raw,
        redirect: 'follow'
      };

      fetch("https://localhost:7032/api/Zone", requestOptions)
        .then(response => response.text())
    }
  }

  const getTroops = () => {
    setTimeout(() => {
      fetch(`https://localhost:7032/api/Zone`)
        .then(response => response.json())
        .then(data => setTroopData(data))
    }, 100)
  }


  useEffect(() => {
    sendTroopInfo(russianTroops)
    getTroops()
  }, [russianTroops])

  // Supplies
  const [supplies, setSupplies] = useState([]);
  const [suppliesDetail, setSuppliesDetail] = useState(null);

  const onMapClickSupplies = useCallback((e) => {
    setSupplies((current) => [
      ...current,
      {
        lat: e.latLng.lat(),
        lng: e.latLng.lng(),
      },
    ]);
  }, []);

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
  }

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
        onClick={itemShownPlacer}
      >
        {page === '1' && (
          <div>
            {troopData.length > 0 && (
              <div>
                {troopData?.map((troop, index) => (
                  <div key={index}>
                    <div>
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
                    </div>
                    <div>
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
                          <div style={{ color: 'black' }}>
                            <h2>Careful! Troop was spotted here</h2>
                            <p>
                              Spotted{" "}
                              {moment(troopData[index].createdAt).calendar()}
                            </p>
                          </div>
                        </InfoWindow>
                      ) : null}
                    </div>
                  </div>

                ))}

                )
              </div>)
            }
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
                    {formatRelative(time, new Date())}
                  </p>
                </div>
              </InfoWindow>
            ) : null}
          </div>
        )}
      </GoogleMap>
    </div>
  )
}

