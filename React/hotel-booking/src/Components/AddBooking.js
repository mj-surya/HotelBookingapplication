import { useState } from "react";
import axios from "axios";
import "./AddBooking.css";
import { Link, useNavigate } from "react-router-dom";

function AddBooking({ room, hotel, onBookingComplete }){
    const [userId,setUserId] = useState(localStorage.getItem("id"));
    const [checkIn,setCheckIn] = useState(hotel.checkIn);
    const [checkOut,setCheckOut] = useState(hotel.checkOut);
    const [roomId,setRoomId] = useState(room.roomId);
    const [totalRoom,setTotalRoom] = useState(1);
    const [payment,setPayment] = useState("");
    const [price, setPrice]=useState(room.price);
    const [totalPrice, setTotalPrice]=useState(room.price);

    const incrementTotalRoom = () => {
        if(totalRoom<=room.totalRooms){
            setTotalRoom((prevCount) => prevCount + 1);
            setTotalPrice(price*totalRoom);
        }
        
    };

    const decrementTotalRoom = () => {
        if (totalRoom > 1) {
            setTotalRoom((prevCount) => prevCount - 1);
            setTotalPrice(price*totalRoom);
        }
    };
    const handlePaymentChange = (e) => {
        setPayment(e.target.value);
    };

    const AddBooking=()=>{
       
     
        axios.post("http://localhost:5272/api/Booking/addBooking",{
            userId : userId,
            checkIn : checkIn,
            checkOut : checkOut,
            roomId : roomId,
            totalRoom : totalRoom,
            payment : payment
        })
        .then((userData)=>{
            alert("Booking successfull");
            onBookingComplete();
            console.log(userData);
        })
        .catch((err)=>{
            alert(err.response.data);
            console.log(err);
        })
       
    }
    return(
        <div class="card addbooking">
            <h4>Room: {room.roomType}</h4>
            <form onSubmit={AddBooking}>
                <input type="date" disabled placeholder="Check-IN" className="form-control space" value={checkIn} />
                <input type="date" disabled placeholder="Check-OUT" className="form-control space" value={checkOut} />

                <div className="container py-4">
                    <div className="row">
                        <div class="col-sm-3 "><h6>Total Rooms:</h6></div>
                        <div className="col-sm-3">
                            <div className="input-group">
                                <span className="input-group-prepend">
                                    <button type="button" className="btn btn-outline-danger btn-number" onClick={decrementTotalRoom}>
                                        <span className="fa fa-minus">-</span>
                                    </button>
                                </span>
                                <input type="text" name="quant[1]" required className="form-control input-number" value={totalRoom} onChange={(e) => { setTotalRoom(e.target.value) }} />
                                <span className="input-group-append">
                                    <button type="button" className="btn btn-outline-primary btn-number" onClick={incrementTotalRoom}>
                                        <span className="fa fa-plus">+</span>
                                    </button>
                                </span>
                            </div>
                        </div>
                    </div>
                </div>

                <label htmlFor="payment">Select Payment Option:</label>
                <select
                    id="payment"
                    name="payment"
                    className="form-control space"
                    value={payment}
                    onChange={handlePaymentChange}>
                    <option value="Pay on Check-In">Pay on Check-In</option>
                    <option value="Online Payment">Online Payment</option>
                </select>
                <h4>Total Price: ₹.{totalPrice}</h4>
                <button className="btn btn-success button space center" >BOOK NOW</button>
            </form>
            
        </div>
    )
}


export default AddBooking;