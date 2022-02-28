import './App.css';
import {BrowserRouter, Route, Routes} from 'react-router-dom';
import RegisterPage from './pages/Register';

function App() {
  return (
    <BrowserRouter>
    <Routes>
      <Route path='/register' element={<RegisterPage />}/>
    </Routes>
    </BrowserRouter>
  );
}

export default App;
