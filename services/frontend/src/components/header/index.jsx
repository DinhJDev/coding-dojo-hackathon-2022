import React, { useState } from "react";

// MUI
import Box from "@mui/material/Box";
import Tab from "@mui/material/Tab";
import TabContext from "@mui/lab/TabContext";
import TabList from "@mui/lab/TabList";
import TabPanel from "@mui/lab/TabPanel";
import Map from "../map";

export default function Header() {
  const [page, setPage] = useState("1");

  const handleChange = (event, newValue) => {
    setPage(newValue);
  };

  return (
    <div style={{position: 'fixed', marginLeft: 240}}>
      <Box sx={{ width: "100%", typography: "body1" }}>
        <TabContext value={page}>
          <Box
            sx={{ borderBottom: 1, borderColor: "divider" }}
            style={{ height: 65 }}
          >
            <TabList onChange={handleChange} aria-label="lab API tabs example">
              <Tab
                label="Potential Danger"
                value="1"
                style={{ textTransform: "none", width: 200, height: 65 }}
              />
              <Tab
                label="Supplies"
                value="2"
                style={{ textTransform: "none", width: 200 }}
              />
              <Tab
                label="Housing"
                value="3"
                style={{ textTransform: "none", width: 200 }}
              />
            </TabList>
          </Box>
          <Map />
          {/* <TabPanel value="1" style={{padding: 0}}> </TabPanel>
          <TabPanel value="2" style={{padding: 0}}></TabPanel>
          <TabPanel value="3" style={{padding: 0}}></TabPanel> */}
        </TabContext>
      </Box>
    </div>
  );
}
