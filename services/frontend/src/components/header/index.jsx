import React, { useState } from "react";

// MUI
import Box from "@mui/material/Box";
import Tab from "@mui/material/Tab";
import TabContext from "@mui/lab/TabContext";
import TabList from "@mui/lab/TabList";
import Map from "../map";
import Toolbar from '@mui/material/Toolbar';
import { createTheme, ThemeProvider} from '@mui/material/styles';

const theme = createTheme({
  palette: {
    text: {
      primary: "#fff"
    },
    background: {
      default: "#6c747d"
    }
  }
});

export default function Header() {
  const [page, setPage] = useState("1");

  const handleChange = (event, newValue) => {
    setPage(newValue);
  };

  return (
    <ThemeProvider theme={theme}>
    <div style={{width: '100%', position: 'fixed', marginLeft: 240, zIndex: 100, backgroundColor: '#262a3b'}}>
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
                style={{ textTransform: "none", width: 200, height: 65, color: "white"}}
              />
              <Tab
                label="Supplies"
                value="2"
                style={{ textTransform: "none", width: 200, color: "white"}}
              />
              <Tab
                label="Housing"
                value="3"
                style={{ textTransform: "none", width: 200, color: "white" }}
              />
            </TabList>
          </Box>
          <Map page={page}/>
        </TabContext>
      </Box>
    </div>
    </ThemeProvider>
  );
}
