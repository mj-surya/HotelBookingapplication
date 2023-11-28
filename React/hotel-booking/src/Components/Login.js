import { useState } from "react";
import axios from "axios";

function Login(){
    const [username,setUsername] = useState("");
    const [password,setPassword] = useState("");

    const login = ()=>{
        axios.post("http://localhost:5272/api/User/login",{
            email: username,
            password:password
        }).then((myData)=>{
            var token = myData.data.token;
            var role = myData.data.role;
            localStorage.setItem("token",token);
            localStorage.setItem("role",role);
            
        })
        .catch((err)=>{
            console.log(err)
        })
    }
return(
    <div>
        <form className="form-group">
        <label className="form-control">Username</label>
        <input type="email" className="form-control" value={username}
                        onChange={(e)=>{setUsername(e.target.value)}}/>
            
        <label className="form-control">Password</label>
        <input type="password" className="form-control" value={password}
                        onChange={(e)=>{setPassword(e.target.value)}}/>

        <button className="btn btn-primary button" onClick={login}>Login</button>
        
        </form>
    </div>
);

}

export default Login;