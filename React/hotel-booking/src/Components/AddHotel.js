import { useState } from "react";
import axios from "axios";
import { Link, Navigate } from "react-router-dom";

function Addhotel(){
    const [hotelname,setHotelname] = useState("");
    const [userId,setUserId] = useState("");
    const [city,setCity] = useState("");
    const [address,setAddress] = useState("");
    const [phone,setPhone] = useState("");
    const [description,setDescription] = useState("");
    var image =null;

    const addHotel = (event)=>{
        event.preventDefault();
        const jsonData = {hotelName: hotelname,
            userId: userId,
            city: city,
            address: address,
            phone: phone,
            description: description
        };
        const formdata = new FormData();
        formdata.append('json',JSON.stringify( jsonData));
        formdata.append('image',image);

        console.log(formdata);
        axios.post("http://localhost:5272/api/hotel/addhotel",formdata,
        {
            headers:{
                'Content-Type':'multipart/form-data',
            }
        })
        .then((userData)=>{
            alert("Hotel added successfully")
            return(<Navigate to="/Home"/>)
            console.log(userData)
        })
        .catch((err)=>{
            alert("Could not add hotel")
            console.log(err)
        })
        
    }
    const handleimg=(e)=>{
        image=e.target.files[0];
        console.log(e.target.files[0]);
    }
    return(
        <div>
            <form className="addhotel">
                <input type="text" required placeholder="Hotel Name" className="form-control" value={hotelname} onChange={(e)=>{setHotelname(e.target.value)}}/>
                <input type="email" placeholder="User Id" className="form-control" value={userId} onChange={(e)=>{setUserId(e.target.value)}}/>
                <input type="text" placeholder="City" className="form-control" value={city} onChange={(e)=>{setCity(e.target.value)}}/>
                <textarea  type="text" placeholder= "Adddress" className="form-control" value={address} onChange={(e)=>{setAddress(e.target.value)}}/>
                <input type="tel" palaceholder="Phone" classNme="form-control" value={phone} onChange={(e)=>{setPhone(e.target.value)}}/>
                <input type="text" placeholder="Description" className="form-control" value={description} onChange={(e)=>{setDescription(e.target.value)}}/>
                <input type="file" accept="image/*" placeholder="Image" className="form-control" value={image} onChange={handleimg} required/>
                <button className="btn btn-primary button" to="/Home" onClick={addHotel} >Add Hotel</button>
            </form>
        </div>
    )

}

export default Addhotel;