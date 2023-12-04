import { useState } from "react";
import axios from "axios";
import "./AddHotel.css";
import { useEffect } from "react";

function AddRoom(){
    const [roomType,setRoomType] = useState("");
    const [hotelId,setHotelId] = useState("");
    const [price,setPrice] = useState(0);
    const [capacity,setCapacity] = useState("");
    const [totalRoom,setTotalRoom] = useState("");
    const [description,setDescription] = useState("");
    const [roomAmenities,setRoomAmenities] = useState([]);
    const [Amenity, setAmenity] = useState("");
    var image = null;

    const addAmenity=(event)=>{
        event.preventDefault();
        if(Amenity.trim()!=='')
        {
            setRoomAmenities([...roomAmenities,Amenity]);
            setAmenity ('');
        }
    }

    useEffect(()=>{
        hotel();
    },[]);
    const hotel=()=>{
        axios.post("http://localhost:5272/api/hotel/getbyid",localStorage.getItem("id"))
        .then((userData)=>{
            const data=userData.data;
            setHotelId(data.hotelId);
            console.log(userData)
        })
        .catch((err)=>{
            console.log(err);
            alert(err.response.data);
        })
    }

    const addRoom=(event)=>{
        const jsonData = {
            roomType : roomType,
            hotelId : hotelId,
            price : price,
            capacity : capacity,
            totalRooms : totalRoom,
            description : description,
            roomAmenities : roomAmenities
        }
        const formdata = new FormData();
        formdata.append('json',JSON.stringify( jsonData));
        formdata.append('image',image);
        console.log(formdata);

        axios.post("http://localhost:5272/api/Room/CreateRooms",formdata,
        {
            headers:{
                'Content-Type':'multipart/form-data',
            }
        })
        .then((userData)=>{
            console.log(userData)
        })
        .catch((err)=>{
            console.log(err)
            event.preventDefault();
            alert(err.response.data);
        })
       
    }
    const handleimg=(e)=>{
        image=e.target.files[0];
        console.log(e.target.files[0]);
    }
    const RemoveAmenity = (index) => {
    const updatedList = [...roomAmenities];
    updatedList.splice(index, 1);
    setRoomAmenities(updatedList);
  };
    return(
        <div class="container contact-form">
            <div class="contact-image">
                <img src="./Logo.png" alt="rocket_contact"/>
            </div>
            <form onSubmit={addRoom}>
                <h3>Add Room </h3>
               <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <input id="roomtype" required name="roomtype" type="text"  class="form-control" placeholder="Room Type" value={roomType} onChange={(e)=>{setRoomType(e.target.value)}} />
                        </div>
                        <div class="form-group">
                          <input type="number" required placeholder="Price" className="form-control" value={price} onChange={(e)=>{setPrice(e.target.value)}}/>
                        </div>
                        <div class="form-group">
                            <input  type="number" required placeholder= "Capacity" className="form-control" value={capacity} onChange={(e)=>{setCapacity(e.target.value)}}/>
                        </div>
                        <div class="form-group">
                        <input  type="number" required placeholder= "Total Rooms" className="form-control" value={totalRoom} onChange={(e)=>{setTotalRoom(e.target.value)}}/>
                        </div>
                        
                    </div>
                    <div class="col-md-6">
                        
                        <div class="form-group">
                            <textarea  id="des" required name="des" class="form-control msg" placeholder="Description" value={description} onChange={(e)=>{setDescription(e.target.value)}} ></textarea>
                        </div>
                        <div class="form-group" >
                            <ul>
                                <p>Amenities : {roomAmenities.length}</p>
                                {roomAmenities.map((item, index) => (
                                <li key={index} >{item} <span onClick={RemoveAmenity}>(remove)</span><br/> </li>
                                ))}
                            </ul>
                                <input type="text" placeholder="Amenities" className="form-control" value={Amenity} onChange={(e)=> {setAmenity(e.target.value)}} />
                                
                                <button className="btn btn-success button" onClick={addAmenity} >Add</button>
                            </div>
                        <div class="form-group">
                            <input type="file" required accept="image/*" class="form-control msg" placeholder="Image" value={image} onChange={handleimg} />
                        </div>
                    </div>
                    <div class="form-group">
                        <button type="submit" className="btn btn-primary button" >Add Hotel</button>
                    </div>
                </div>
            </form>
        </div>
    )
}
export default AddRoom;