import './App.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom'

import Maps from './pages/Maps';

function App() {
  return (
    <div>
        <Router>
          <Routes>
            {/* Change later if there is a signup/signin page  */}
            <Route exact path='/' element={<Maps />}/>
          </Routes>
        </Router>
    </div>
  );
}

export default App;
