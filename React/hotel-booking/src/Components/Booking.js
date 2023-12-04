import { useState } from "react";
import axios from "axios";
import { useEffect } from "react";

function Booking(){
    const [bookingList, setBookingList] = useState([]);

    useEffect(()=>{
        getBooking();
    },[]);

    var getBooking = ()=>{
        axios.get('http://localhost:5272/api/Booking/userBooking',{
            params: {
              id : localStorage.getItem("id")
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

    var CheckBooking = bookingList.length>0 ? true : false
    return(
        <div>
            {CheckBooking?
                <div>
                    {bookingList.map((booking)=>
                        <div key={booking} class="card">
                            <div class="row">
                                <div class="col-3">
                                <h5 class="card-title">{booking.userId}</h5>
                                <h5 class="card-title">{booking.roomId}</h5>
                                </div>
                                <div class="col-6">
                                    <div class="card-body">
                                    <h5 class="card-title">{booking.checkIn}</h5>
                                    <h5 class="card-title">{booking.checkOut}</h5>
                                    <h5 class="card-title">{booking.totalRoom}</h5>
                                    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                                    </div>
                                </div>
                                < div class="col-3">
                                    
                                    <button className="btn btn-danger">Cancel</button>
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

export default Booking;