
import './App.css';
import Hotels from './Components/Hotels';
import AddHotel from './Components/AddHotel';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Menu from './Components/Menu';
import Register from './Components/Register';
import Protected from './Protected';
import Login from './Components/Login';
import MenuUser from './Components/MenuUser';


function App() {
  var usertype = localStorage.getItem('role');
  return (
    <div>
      <BrowserRouter>
      {usertype==="Admin"?<Menu/> : <MenuUser/> }
        <Routes>
          <Route path="Register" element={<Register/>} />
          <Route path="Home" element={<Hotels />} />
          <Route path="Login" element={<Login />} />
          <Route
            path="AddHotel"
            element={
              <Protected>
                <AddHotel />
              </Protected>
            }/>
        </Routes>
        
      </BrowserRouter>
    </div>
  );
}


export default App;
