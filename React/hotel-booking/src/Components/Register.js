import { useState } from "react";
import axios from "axios";

function Register(){
    const roles =["User","Admin"];
    const [username,setUsername] = useState("");
    const [password,setPassword] = useState("");
    const [repassword,setrePassword] = useState("");
    const [role,setRole] = useState("");
    const [name,setName] = useState("");
    const [address,setAddress] = useState("");
    const [phone,setPhone] = useState("");
    
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
        .then((userData)=>{
            console.log(userData)
        })
        .catch((err)=>{
            console.log(err)
        })
    }
        return (
            <div >
              <form className="registerForm">
                <label className="form-control">Name</label>
                <input type="text" className="form-control" value={name}
                        onChange={(e)=>{setName(e.target.value)}}/>
                <label className="form-control">Username</label>
                <input type="email" className="form-control" value={username}
                        onChange={(e)=>{setUsername(e.target.value)}}/>
            
                <label className="form-control">Password</label>
                <input type="password" className="form-control" value={password}
                        onChange={(e)=>{setPassword(e.target.value)}}/>
                <label className="form-control">Re-Type Password</label>
                <input type="password" className="form-control" value={repassword}
                        onChange={(e)=>{setrePassword(e.target.value)}}/>

                <label className="form-control">Phone</label>
                <input type="tel" className="form-control" value={phone}
                        onChange={(e)=>{setPhone(e.target.value)}}/>
                <label className="form-control">Address</label>
                <textarea  type="text" className="form-control" value={address}
                        onChange={(e)=>{setAddress(e.target.value)}}/>

                <label className="form-control">Role</label>
                <select className="form-select" onChange={(e)=>{setRole(e.target.value)}}>
                    <option value="select">Select Role</option>
                    {roles.map((r)=>
                        <option value={r} key={r}>{r}</option>
                    )}
            </select>
            
            
           
            <br/>
            <button className="btn btn-primary button" onClick={signUp}>Sign Up</button>
        </form>
            </div>
          );

}

export default Register;