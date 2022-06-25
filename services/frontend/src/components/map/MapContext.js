import React, { useContext } from 'react';

const MapContext = React.createContext();
export const useMapContext = () => useContext(MapContext);

export default MapContext;