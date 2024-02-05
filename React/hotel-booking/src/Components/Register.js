import { useState } from "react";
import axios from "axios";
import { Link, useNavigate } from "react-router-dom";
import './Login.css';

function Register(){
    const roles =["User","Admin"];
    const [username,setUsername] = useState("");
    const [password,setPassword] = useState("");
    const [repassword,setrePassword] = useState("");
    const [role,setRole] = useState("User");
    const [name,setName] = useState("");
    const [address,setAddress] = useState("");
    const [phone,setPhone] = useState("");
    const navigate =useNavigate();
    

    const admin=()=>{
        setRole("Admin");
    }
    const user=()=>{
        setRole("User");
    }
    const signUp = (event)=>{
        event.preventDefault();
        axios.post("http://localhost:5272/api/User/register",{
            email: username,
            role:	role,
            password:password,
            address : address,
            phone : phone,
            name : name,
            reTypePassword : repassword
        })
        .then (async (userData)=>{
            var token = await userData.data.token;
            await localStorage.setItem("token",token);
            await localStorage.setItem("role",userData.data.role);
            await localStorage.setItem("id",userData.data.email);
            await localStorage.setItem("name",userData.data.name);
            alert("Registeration Successfull...");
            navigate("/Home");
            window.location.reload();
        })
        .catch((err)=>{
            alert(err.response.data);
        })
    }
        return (
            <div class="wrapper crollspy-example" data-bs-spy="scroll">
                <div class="logo">
                    <img src="./Logo.png" alt=""/>
                </div>
                <div class="text-center mt-4 name">
                    Stay Quest
                </div>
                <form class="p-3 mt-3" onSubmit={signUp}>
                    <div class="form-field d-flex align-items-center">
                        <span class="far fa-user"></span>
                        <input type="text"  required value={name} placeholder="Name" onChange={(e)=>{setName(e.target.value)}}/>
                    </div>
                    <div class="form-field d-flex align-items-center">
                        <span class="far fa-user"></span>
                        <input type="email"  required value={username} placeholder="Email" onChange={(e)=>{setUsername(e.target.value)}}/>
                    </div>
                    <div class="form-field d-flex align-items-center">
                        <span class="fas fa-key"></span>
                        <input type="password"  required placeholder="Password" value={password} onChange={(e)=>{setPassword(e.target.value)}}/>
                    </div>
                    <div class="form-field d-flex align-items-center">
                        <span class="far fa-user"></span>
                        <input type="password"  required value={repassword} placeholder="Re-Type Password" onChange={(e)=>{setrePassword(e.target.value)}}/>
                    </div>
                    <div class="form-field d-flex align-items-center">
                        <span class="far fa-user"></span>
                        <input type="tel"  required value={phone} placeholder="Phone" onChange={(e)=>{setPhone(e.target.value)}}/>
                    </div>
                    <div class="form-field d-flex align-items-center">
                        <span class="far fa-user"></span>
                        <textarea type="text"  required value={address} placeholder="Address" onChange={(e)=>{setAddress(e.target.value)}}/>
                    </div>
                    
                    <button type="submit" class="btn mt-3" >{role==='User' ? "Register as User": "Register as Hotel Manager"}</button>
                </form>
                
                <div class="text-center fs-6">
                    {role==='User' ? <Link to="/Register" onClick ={admin}>Register as Hotel Manager</Link> : <Link to="/Register" onClick ={user}>Register as User</Link>}
                 
                </div>
                <div class="text-center fs-6">
                or <Link to="/Login">Login</Link>
                </div>
            </div>
          );

}

export default Register;