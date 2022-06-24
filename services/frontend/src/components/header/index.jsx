import React, {useState} from "react";

// MUI
import Box from "@mui/material/Box";
import Tab from "@mui/material/Tab";
import TabContext from "@mui/lab/TabContext";
import TabList from "@mui/lab/TabList";
import TabPanel from "@mui/lab/TabPanel";

export default function Header() {
  const [page, setPage] = useState("1");

  const handleChange = (event, newValue) => {
    setPage(newValue);
  };

  return (
    <Box sx={{ width: "100%", typography: "body1" }}>
      <TabContext value={page}>
        <Box sx={{ borderBottom: 1, borderColor: "divider" }}>
          <TabList onChange={handleChange} aria-label="lab API tabs example">
            <Tab label="Potential Danger" value="1" style={{textTransform: 'none'}}/>
            <Tab label="Item Two" value="2" style={{textTransform: 'none'}}/>
            <Tab label="Item Three" value="3" style={{textTransform: 'none'}}/>
          </TabList>
        </Box>
        <TabPanel value="1">Item One</TabPanel>
        <TabPanel value="2">Item Two</TabPanel>
        <TabPanel value="3">Item Three</TabPanel>
      </TabContext>
    </Box>
  );
}
