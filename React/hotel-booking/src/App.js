
import './App.css';
import Hotels from './Components/Hotels';
import AddHotel from './Components/AddHotel';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Menu from './Components/Menu';
import Register from './Components/Register';
import Protected from './Protected';
import Login from './Components/Login';
import MenuUser from './Components/MenuUser';
import AddRoom from './Components/AddRoom';
import Rooms from './Components/Rooms';


function App() {
  var usertype = localStorage.getItem('role');
  return (
      <BrowserRouter>
      {usertype==="Admin"?<Menu/> : <MenuUser/> }
      <div className='margin'>
      <Routes>
          <Route path="Register" element={<Register/>} />
          <Route path="Home" element={<Hotels />} />
          <Route path="Login" element={<Login />} />
          <Route path="AddRoom" element={<AddRoom/>}/>
          <Route path="GetRoom" element={<Rooms/>}/>
          <Route
            path="AddHotel"
            element={
              <Protected>
                <AddHotel />
              </Protected>
            }/>
        </Routes>
      </div>
      </BrowserRouter>
  );
}


export default App;
