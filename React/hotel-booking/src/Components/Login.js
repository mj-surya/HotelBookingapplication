import { useState } from "react";
import axios from "axios";
import { Link, useNavigate } from "react-router-dom";
import './Login.css';

function Login(){
    const [username,setUsername] = useState("");
    const [password,setPassword] = useState("");
    const navigate = useNavigate();

    const login = (event)=>{
        event.preventDefault();
        axios.post("http://localhost:5272/api/User/login",{
            email: username,
            password:password
        }).then( async(myData)=>{
            var token = await myData.data.token;
            var role = await myData.data.role;
            await localStorage.setItem("token",token);
            await localStorage.setItem("role",role);
            await localStorage.setItem("id",myData.data.email);
            await localStorage.setItem("name",myData.data.name);
            alert("Login Successfull...");
            navigate("/Home");
            window.location.reload();
        })
        .catch((err)=>{
            alert(err.response.data);
        })        
    }
return(
    <div class="wrapper">
        <div class="logo">
            <img src="./Logo.png" alt=""/>
        </div>
        <div class="text-center mt-4 name">
            Stay Quest
        </div>
        <form class="p-3 mt-3" onSubmit={login}>
            <div class="form-field d-flex align-items-center">
                <span class="far fa-user"></span>
                <input type="email" value={username} placeholder="Username" onChange={(e)=>{setUsername(e.target.value)}} required/>
            </div>
            <div class="form-field d-flex align-items-center">
                <span class="fas fa-key"></span>
                <input type="password" required placeholder="Password" value={password} onChange={(e)=>{setPassword(e.target.value)}}/>
            </div>
            <button type="submit" class="btn mt-3" >Login</button>
        </form>
        <div class="text-center fs-6">
         or <Link to="/Register">Sign up</Link>
        </div>
    </div>
);

}

export default Login;