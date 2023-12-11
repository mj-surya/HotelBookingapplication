import { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import './AddHotel.css';

function Addhotel(){
    const [hotelname,setHotelname] = useState("");
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
                Authorization: `Bearer ${localStorage.getItem("token")}`,
                'Content-Type':'multipart/form-data',
            }
        })
        .then(async (userData)=>{
            alert("Hotel added successfully")
            navigate("/Home");
        })
        .catch((err)=>{
            alert(err.response.data);
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
            <form onSubmit={addHotel}>
                <h3>Register Your Hotel</h3>
               <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <input id="hotelname" required name="hotelname" type="text"  class="form-control" placeholder="Hotel Name *" value={hotelname} onChange={(e)=>{setHotelname(e.target.value)}} />
                        </div>
                        <div class="form-group">
                            <input id="city" required  name="city" type="text"  class="form-control" placeholder="City *" value={city} onChange={(e)=>{setCity(e.target.value)}} />
                        </div>
                        <div class="form-group">
                            <textarea id="haddress" required name="haddress" type="text"  class="form-control" placeholder="Address *" value={address} onChange={(e)=>{setAddress(e.target.value)}} />
                        </div>
                        
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <input id="hphone" required name="hphone" type="tel"  class="form-control" placeholder="Phone *" value={phone} onChange={(e)=>{setPhone(e.target.value)}} />
                        </div>
                        <div class="form-group">
                            <textarea  id="des" required name="des" class="form-control msg" placeholder="Description *" value={description} onChange={(e)=>{setDescription(e.target.value)}} ></textarea>
                        </div>
                        <div class="form-group">
                            <input type="file" required accept="image/*" class="form-control msg" placeholder="Image *" value={image} onChange={handleimg} />
                        </div>
                    </div>
                    <div class="form-group">
                        <button className="btn btn-primary button" >Add Hotel</button>
                    </div>
                </div>
            </form>
        </div>
    )

}

export default Addhotel;