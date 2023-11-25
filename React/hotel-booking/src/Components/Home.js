// src/components/HomePage.js
import React, { useState } from 'react';

import Register from './Register';

const Home = () => {

  const [registerShow, setRegisterShow] = useState(false);

  

  const showRegisterModal = () => setRegisterShow(true);
  const hideRegisterModal = () => setRegisterShow(false);

  return (
    <div>
      
      <button onClick={showRegisterModal}>Register</button>

   
      <Register show={registerShow} handleClose={hideRegisterModal} />
    </div>
  );
};

export default Home;