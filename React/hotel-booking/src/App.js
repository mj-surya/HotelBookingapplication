
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
import AddBooking from './Components/AddBooking';
import Booking from './Components/Booking';
import Reviews from './Components/Reviews';
import ViewHotel from './Components/ViewHotel';
import AddReview from './Components/AddReview';
import UpdateUser from './Components/UpdateUser';
import Home from './Components/Home';





function App() {
  var usertype = localStorage.getItem('role');
  return (
    <div class="padding bg">

      {/* <BrowserRouter>
      {usertype==="Admin"?<Menu/> : <MenuUser/> }
      <div className='margin'>
      <Routes>
          <Route path="Register" element={<Register/>} />
          <Route path="Home" element={<Hotels />} />
          <Route path="Login" element={<Login />} />
          <Route path="AddRoom" element={<AddRoom/>}/>
          <Route path="GetRoom" element={<Rooms/>}/>
          <Route path="ViewHotel" element={<ViewHotel/>}/>
          <Route path="Reviews" element={<Reviews/>}/>
          <Route path="AddReview" element={<AddReview/>}/>
          <Route path="AddBooking" element={<AddBooking/>}/>
          <Route path="Booking" element={<Booking/>}/>
          <Route
            path="AddHotel"
            element={
              <Protected>
                <AddHotel />
              </Protected>
            }/>
        </Routes>
      </div>
      </BrowserRouter> */}

      <Booking/>
      
     

    </div>
  );
}


export default App;
