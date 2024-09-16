import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import App from './App.jsx'
import './index.css'
import 'bootstrap/dist/css/bootstrap.min.css';
import RouterCustom from './router';
import { BrowserRouter } from "react-router-dom";
createRoot(document.getElementById('root')).render(
  <BrowserRouter>
    <RouterCustom />
  </BrowserRouter>

)

