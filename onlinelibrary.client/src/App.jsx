import './App.css';

import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Home from './Pages/Home.jsx';
import Login from './Pages/Login.jsx';
import Register from './Pages/Register.jsx';
function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/loginpage" element={<Login />} />
                <Route path="/registerpage" element={<Register />} />
            </Routes>
        </BrowserRouter>
    )
}

export default App;