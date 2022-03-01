import './App.css';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import RegisterPage from './components/pages/Register';
import { useState } from 'react';

function App() {
  const [users, setUsers] = useState([]);

  const onUserAdded = (user) => {
    setUsers(users => {
      users.push(user);
      return users;
    })
  };
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/register' element={<RegisterPage onSubmit={onUserAdded} />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
