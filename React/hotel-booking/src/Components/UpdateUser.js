

import { useEffect, useState } from "react";
import axios from "axios";

function UpdateUser(){
    const [username,setUsername] = useState("");
    const [role,setRole] = useState("");
    const [name,setName] = useState("");
    const [address,setAddress] = useState("");
    const [phone,setPhone] = useState("");
    

    useEffect(()=>{
        getUser();
    },[]);
    const getUser=()=>{
        axios.get('http://localhost:5272/api/User/Get',{
            params: {
              id : localStorage.getItem("id")
            }
          })
          .then((response) => {
            const posts = response.data;
            console.log(posts);
            setUsername(posts.email);
            setAddress(posts.address);
            setName(posts.name);
            setPhone(posts.phone);
            setRole(posts.role);
            
        })
       
    }

    const save=(event)=>{
        event.preventDefault();
        const jsonData = {
           name : name,
           address : address,
           phone : phone     
        };
       
        axios.put("http://localhost:5272/api/User/Update",jsonData,{
            params :{
                id : username
            }
        })
        .then(async (userData)=>{
            alert("Profile updated successfully");
            getUser();
        })
        .catch((err)=>{
            alert("Could not update ");
            
        })
    }

    return (
        <div class="wrapper">
            <div class="logo">
                <img src="./Logo.png" alt=""/>
            </div>
            <div class="text-center mt-4 name">
                User Profile
            </div>
            <form class="p-3 mt-3">
                <div class="form-field d-flex align-items-center">
                    <span class="far fa-user"></span>
                    <input type="text"  value={name} placeholder="Name" onChange={(e)=>{setName(e.target.value)}}/>
                </div>
                <div class="form-field d-flex align-items-center">
                    <span class="far fa-user"></span>
                    <input type="email"  value={username} placeholder="Email" onChange={(e)=>{setUsername(e.target.value)}} disabled/>
                </div>
                <div class="form-field d-flex align-items-center">
                    <span class="far fa-user"></span>
                    <input type="tel"  value={phone} placeholder="Phone" onChange={(e)=>{setPhone(e.target.value)}}/>
                </div>
                <div class="form-field d-flex align-items-center">
                    <span class="far fa-user"></span>
                    <textarea type="text"  value={address} placeholder="Address" onChange={(e)=>{setAddress(e.target.value)}}/>
                </div>
                <div class="form-field d-flex align-items-center">
                    <span class="far fa-user"></span>
                    <input type="text"  value={role} placeholder="Role" onChange={(e)=>{setName(e.target.value)}} disabled/>
                </div>
                <button type="submit" class="btn mt-3" onClick={save}>Save</button>
            </form>
           
        </div>
      );

}

export default UpdateUser;