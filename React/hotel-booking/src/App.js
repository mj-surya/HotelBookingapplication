import './App.css';
import Hotels from './Components/Hotels';
import AddHotel from './Components/AddHotel';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Menu from './Components/Menu';
import Register from './Components/Register';
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
import GuestPolicies from './Components/GuestPolicies';
import PrivacyPolicy from './Components/PrivacyPolicy';
import TrustAndSafety from './Components/TrustAndSafety';
import AboutUs from './Components/AboutUs';
import AdminBooking from './Components/AdminBooking';
import TermsAndCondition from './Components/TermsAndCondition';
import ViewAdminHotel from './Components/ViewAdminHotel';
import AdminRooms from './Components/AdminRooms';
import Payment from './Components/Payment';






function App() {
  var usertype = localStorage.getItem('role');
  return (
    <div class="padding bg">

      <BrowserRouter>
      {usertype==="Admin"?<Menu/> : <MenuUser/> }
      <div className='margin'>
      <Routes>
          <Route path="AboutUs" element={<AboutUs/>}/>
          <Route path="AddBooking" element={<AddBooking/>}/>
          <Route path="AddHotel" element={<AddHotel />}/>
          <Route path="AddReview" element={<AddReview/>}/>
          <Route path="AddRoom" element={<AddRoom/>}/>
          <Route path="AdminBooking" element={<AdminBooking/>}/>
          <Route path="Booking" element={<Booking/>}/>
          <Route path="GuestPolicy" element={<GuestPolicies/>}/>
          <Route path="Home" element={<Home />} />
          <Route path="Hotels" element={<Hotels />} />
          <Route path="Login" element={<Login />} />
          <Route path="PrivacyPolicy" element={<PrivacyPolicy/>}/>
          <Route path="Register" element={<Register/>} />
          <Route path="Reviews" element={<Reviews/>}/>
          <Route path="Rooms" element={<Rooms/>}/>
          <Route path="TermsAndCondition" element={<TermsAndCondition/>}/>
          <Route path="TrustAndSafety" element={<TrustAndSafety/>}/>
          <Route path="UpdateUser" element={<UpdateUser />} />
          <Route path="ViewHotel" element={<ViewHotel/>}/>
          <Route path="ViewAdminHotel" element={<ViewAdminHotel/>}/>
          <Route path="AdminRooms" element={<AdminRooms/>}/>
          <Route path="Payment" element={<Payment/>}/>
        </Routes>
      </div>
      </BrowserRouter>
      
    </div>
  );
}


export default App;
