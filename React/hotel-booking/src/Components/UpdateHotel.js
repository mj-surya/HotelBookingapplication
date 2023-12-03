import { useEffect, useState } from "react";
import axios from "axios";
import { Link, useNavigate } from "react-router-dom";


function UpdateHotel(){
    const [hotelname,setHotelname] = useState("");
    
    const [city,setCity] = useState("");
    const [address,setAddress] = useState("");
    const [phone,setPhone] = useState("");
    const [description,setDescription] = useState("");
    const [hotel, setHotel] = useState([]);

    //const navigate = useNavigate();
   

    const updateHotel = (event)=>{
        event.preventDefault();
        const jsonData = {
           
            hotelName: hotelname,
            city: city,
            address: address,
            phone: phone,
            description: description,
            
        };
       
        axios.put("http://localhost:5272/api/hotel/UpdateHotel",jsonData,{
            params :{
                id :hotel.hotelId
            }
        })
        .then(async (userData)=>{
            alert("Hotel updated successfully")
         //   navigate("/Home");
        })
        .catch((err)=>{
            alert("Could not update hotel")
            console.log(err)
            
        })
        
    }
    useEffect(()=>{
        getHotel();
    },[]);
    const getHotel=()=>{
        axios.get('http://localhost:5272/api/Hotel/GetById',{
            params: {
              id : 'mj@gmail.com'
            }
          })
          .then((response) => {
            const posts = response.data;
            console.log(posts);
            setHotel(posts);
            setCity(posts.city);
            setAddress(posts.hotelName);
            setDescription(posts.description);
            setHotelname(posts.hotelName);
            setPhone(posts.phone);
          
        })
        .catch(function (error) {
            alert("Could not get hotel")
         
           
        })
    }
    const deleteHotel=(event)=>{
        event.preventDefault();

        axios.delete("http://localhost:5272/api/hotel/RemoveHotel",{
            params : {
               id : hotel.hotelId
            }
        }

        )
        .then(async (userData)=>{
            alert("Hotel deleted successfully")
       //     navigate("/Home");
        })
        .catch((err)=>{
            alert("Could not delete hotel")
            console.log(err)
        })
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
                        
                    </div>
                    <div class="form-group">
                        <button className="btn btn-primary button" onClick={updateHotel} >Update Hotel</button>
                        <button className="btn btn-primary button" onClick={deleteHotel} >Delete Hotel</button>
                    </div>
                </div>
            </form>
        </div>
    )

}

export default UpdateHotel;