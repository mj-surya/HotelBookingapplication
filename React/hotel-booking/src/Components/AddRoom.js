import { useState } from "react";
import axios from "axios";

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

    const addRoom=(event)=>{
        event.preventDefault();
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
        <div>
            <form>
                <input type="text" placeholder="Room Type" className="form-control" value={roomType} onChange={(e)=>{setRoomType(e.target.value)}}/>
                <input type="number" placeholder="Hotel Id" className="form-control" value={hotelId} onChange={(e)=>{setHotelId(e.target.value)}}/>
                <input type="number" placeholder="Price" className="form-control" value={price} onChange={(e)=>{setPrice(e.target.value)}}/>
                <input  type="number" placeholder= "Capacity" className="form-control" value={capacity} onChange={(e)=>{setCapacity(e.target.value)}}/>
                <input type="number" palaceholder="Total Room" classNme="form-control" value={totalRoom} onChange={(e)=>{setTotalRoom(e.target.value)}}/>
                <input type="text" placeholder="Description" className="form-control" value={description} onChange={(e)=>{setDescription(e.target.value)}}/>
                <div >
                <ul>
                    <p>Amenities : {roomAmenities.length}</p>
                    {roomAmenities.map((item, index) => (
                    <li key={index} >{item} <span onClick={RemoveAmenity}>(remove)</span> </li>
                    ))}
                </ul>
                    <input type="text" placeholder="Amenities" className="form-control" value={Amenity} onChange={(e)=> {setAmenity(e.target.value)}} />
                    
                    <button className="btn btn-success button" onClick={addAmenity} >Add</button>
                </div>
                <input type="file" accept="image/*" placeholder="Image" className="form-control" value={image} onChange={handleimg}/>
                <button className="btn btn-primary button" onClick={addRoom}>Add Room</button>
            </form>
        </div>
    )
}
export default AddRoom;