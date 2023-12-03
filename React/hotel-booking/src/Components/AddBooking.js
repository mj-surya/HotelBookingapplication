import { useState } from "react";
import axios from "axios";
import { Link, useNavigate } from "react-router-dom";

function AddBooking(){
    const [userId,setUserId] = useState("");
    const [checkIn,setCheckIn] = useState("");
    const [checkOut,setCheckOut] = useState("");
    const [roomId,setRoomId] = useState(1);
    const [totalRoom,setTotalRoom] = useState(1);
    const [payment,setPayment] = useState("");
    const navigate = useNavigate();

    const AddBooking=(event)=>{
        event.preventDefault();
       
     
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
            navigate("/Home");
            console.log(userData);
        })
        .catch((err)=>{
            alert("Booking failed");
            console.log(err);
        })
       
    }
    return(
        <div>
            <form >
                <input type="email" required placeholder="UserId" className="form-control" value={userId} onChange={(e)=>{setUserId(e.target.value)}}/>
                <input type="text" placeholder="Check-IN" className="form-control" value={checkIn} onChange={(e)=>{setCheckIn(e.target.value)}}/>
                <input type="text" placeholder="Check-OUT" className="form-control" value={checkOut} onChange={(e)=>{setCheckOut(e.target.value)}}/>
                <input  type="number" placeholder= "RoomId" className="form-control" value={roomId} onChange={(e)=>{setRoomId(e.target.value)}}/>
                <input type="number" palaceholder="Total Room" classNme="form-control" value={totalRoom} onChange={(e)=>{setTotalRoom(e.target.value)}}/>
                <input type="text" placeholder="Payment option" className="form-control" value={payment} onChange={(e)=>{setPayment(e.target.value)}}/>
                <button className="btn btn-primary button" onClick={AddBooking} >BOOK</button>
            </form>
        </div>
    )
}


export default AddBooking;