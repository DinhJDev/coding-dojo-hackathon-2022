import React from "react";
import Header from '../../components/header';
import Sidebar from '../../components/sidebar';

export default function Home() {
  return (
    <div>
      <div style={{display: 'flex', position: "absolute",  zIndex: 100}}>
        <Sidebar />
        <Header />
      </div>
      <div>
      </div>
    </div>
  );
}
