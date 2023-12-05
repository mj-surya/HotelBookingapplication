import { useState } from "react";
import axios from "axios";
import { useEffect } from "react";
import './Booking.css';

function AdminBooking(){
    const [bookingList, setBookingList] = useState([]);

    useEffect(()=>{
        hotel();
    },[]);

    const hotel=()=>{
        axios.get('http://localhost:5272/api/hotel/getbyid',{
            params:{
                id:localStorage.getItem('id')
            }
        })
        .then((response)=>{
            console.log(response);
            const posts=response.data;
            console.log(posts.hotelId);
            getBooking(posts.hotelId);
        })
        .catch((error)=>{
            console.log(error);
        })
        
    }
    const getBooking = (id)=>{
        axios.get('http://localhost:5272/api/Booking/adminbooking',{
            params: {
              id :id
            },
            headers:{
                Authorization: `Bearer ${localStorage.getItem("token")}`
            }
          })
          .then((response) => {
            const posts = response.data;
            console.log(posts);
            setBookingList(posts);
        })
        .catch(function (error) {
            alert(error.response.data);
            console.log(error);
        })
    }
    const cancel = (bookingId) => {
        console.log(bookingId);
        axios.put(`http://localhost:5272/api/Booking/Update?id=${bookingId}&status=Cancelled`)
          .then((response) => {
            alert("Booking Cancelled");
          })
          .catch(function (error) {
            alert("Could not cancel booking.");
            console.log(error);
          });
      }
      
      
    const isCheckInDatePassed = (checkInDate) => {
        const currentDate = new Date();
        const checkIn = new Date(checkInDate);
        return currentDate > checkIn;
    };
    var CheckBooking = bookingList.length>0 ? true : false
    return(
        <div>
            {CheckBooking?
                <div>
                    {bookingList.map((booking)=>
                        <div key={booking} class="card booking">
                            <div class="row">
                                <div class="col">
                                <h3 class="card-title">{booking.hotelName}</h3>
                                <h5 class="card-title">Room Type: {booking.roomType}</h5>
                                <p class ="card-description">Booked on: {booking.bookingDate}</p>
                                </div>
                                <div class="col">
                                    <div class="card-body">
                                        <h5 class="card-title">Booking ID: {booking.bookingId}</h5>
                                        <h5 class="card-title">Check-In: {booking.checkIn}</h5>
                                        <h5 class="card-title">Check-Out: {booking.checkOut}</h5>
                                        
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="card-body">
                                        <h5 class="card-title">Rooms Booked: {booking.totalRoom}</h5>
                                        <h5 class="card-title">Total Amount: ₹.{booking.price}</h5>
                                        <h5 class="card-title">Payment: {booking.payment}</h5>
                                    </div>
                                </div>
                                < div class="col">
                                    <h5 class="card-title">Status: {booking.status}</h5>
                                    {isCheckInDatePassed(booking.checkIn) || booking.status=='Cancelled' ? null : ( <button className="btn btn-danger" onClick={() => cancel(booking.bookingId)}>Cancel</button>)}
                                </div>
                            </div>
                        </div>
                    )}
                </div>
                :
                <div>No bookings available</div>
            }
        </div>
    )
}

export default AdminBooking;