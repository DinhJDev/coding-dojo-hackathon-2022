import React from "react";

export default function GeoLocation({ panTo }) {
  return (
    <button
      className="locate"
      style={{ cursor: 'pointer', position: 'absolute', zIndex: 100, backgroundColor: 'transparent', border: 'none'}}
      onClick={() => {
        navigator.geolocation.getCurrentPosition(
          (position) => {
            panTo({
              lat: position.coords.latitude,
              lng: position.coords.longitude,
            });
          },
          () => null
        );
      }}
    >
      <img style={{width: 40, position: 'fixed', bottom: 25, right: 25}} src="/marker.svg" alt="compass" />
    </button>
  );
}
