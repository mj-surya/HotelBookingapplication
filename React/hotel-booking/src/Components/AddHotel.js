import { useState } from "react";
import axios from "axios";
import { Link, useNavigate } from "react-router-dom";
import './AddHotel.css';

function Addhotel(){
    const [hotelname,setHotelname] = useState("");
    const [userId,setUserId] = useState("");
    const [city,setCity] = useState("");
    const [address,setAddress] = useState("");
    const [phone,setPhone] = useState("");
    const [description,setDescription] = useState("");
    const navigate = useNavigate();
    var image =null;

    const addHotel = (event)=>{
        event.preventDefault();
        const jsonData = {hotelName: hotelname,
            userId: localStorage.getItem("id"),
            city: city,
            address: address,
            phone: phone,
            description: description
        };
        const formdata = new FormData();
        formdata.append('json',JSON.stringify( jsonData));
        formdata.append('image',image);

        axios.post("http://localhost:5272/api/hotel/addhotel",formdata,
        {
            headers:{
                'Content-Type':'multipart/form-data',
            }
        })
        .then(async (userData)=>{
            alert("Hotel added successfully")
            navigate("/Home");
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
        <div class="container contact-form">
            <div class="contact-image">
                <img src="./Logo.png" alt="rocket_contact"/>
            </div>
            <form>
                <h3>Register Your Hotel</h3>
               <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <input id="hotelname" name="hotelname" type="text"  class="form-control" placeholder="Hotel Name *" value={hotelname} onChange={(e)=>{setHotelname(e.target.value)}} />
                        </div>
                        <div class="form-group">
                            <input id="city" name="city" type="text"  class="form-control" placeholder="City *" value={city} onChange={(e)=>{setCity(e.target.value)}} />
                        </div>
                        <div class="form-group">
                            <textarea id="haddress" name="haddress" type="text"  class="form-control" placeholder="Address *" value={address} onChange={(e)=>{setAddress(e.target.value)}} />
                        </div>
                        
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <input id="hphone" name="hphone" type="tel"  class="form-control" placeholder="Phone *" value={phone} onChange={(e)=>{setPhone(e.target.value)}} />
                        </div>
                        <div class="form-group">
                            <textarea  id="des" name="des" class="form-control msg" placeholder="Description *" value={description} onChange={(e)=>{setDescription(e.target.value)}} ></textarea>
                        </div>
                        <div class="form-group">
                            <input type="file" accept="image/*" class="form-control msg" placeholder="Image *" value={image} onChange={handleimg} />
                        </div>
                    </div>
                    <div class="form-group">
                        <Link className="btn btn-primary button" onClick={addHotel} >Add Hotel</Link>
                    </div>
                </div>
            </form>
        </div>
    )

}

export default Addhotel;