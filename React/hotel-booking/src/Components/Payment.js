import { useEffect } from 'react';
import { useState } from 'react';
import './Payment.css';

function Payment(){
    const [Amount,setAmount]= useState(1000);
    const [cardnumber,setCardNumber] = useState("");
    const [displaynum,setdisplaynum]= useState("");
    const [cardname,setCardName] = useState("");
    const [cardMM,setCardMM] = useState("");
    const [cardYY,setCardYY] = useState("");
    const [cardCVV,setCardCVV] = useState("");
    const [zip,setZip] = useState("");

    useEffect(()=>{
        cardnum();
    },[cardnumber]);
    const cardnum=()=>{
        let format='';
        let numbers=cardnumber;
        if(numbers.length==0){
            numbers="****************";
        }
        for(let i=0;i<numbers.length;i++){
            if(i>0 && i%4===0){
                format+=' ';
            }
            format+=numbers[i];
        }
        setdisplaynum(format);
    }

    


    return(
        <div class="payment">
            <div class="container">
      <div class="row">
        <div class="col-sm-4 mx-auto my-5">
          <div id="cardDesign" class="position-relative shadow p-4">
            <div class="d-flex align-items-center justify-content-between">
              <div class="fs-4"><strong>₹. {Amount}</strong></div>
              <div><svg xmlns="http://www.w3.org/2000/svg" width="25" height="25" fill="currentColor" class="bi bi-wifi" viewBox="0 0 16 16">
  <path d="M15.384 6.115a.485.485 0 0 0-.047-.736A12.44 12.44 0 0 0 8 3C5.259 3 2.723 3.882.663 5.379a.485.485 0 0 0-.048.736.52.52 0 0 0 .668.05A11.45 11.45 0 0 1 8 4c2.507 0 4.827.802 6.716 2.164.205.148.49.13.668-.049"/>
  <path d="M13.229 8.271a.482.482 0 0 0-.063-.745A9.46 9.46 0 0 0 8 6c-1.905 0-3.68.56-5.166 1.526a.48.48 0 0 0-.063.745.525.525 0 0 0 .652.065A8.46 8.46 0 0 1 8 7a8.46 8.46 0 0 1 4.576 1.336c.206.132.48.108.653-.065m-2.183 2.183c.226-.226.185-.605-.1-.75A6.5 6.5 0 0 0 8 9c-1.06 0-2.062.254-2.946.704-.285.145-.326.524-.1.75l.015.015c.16.16.407.19.611.09A5.5 5.5 0 0 1 8 10c.868 0 1.69.201 2.42.56.203.1.45.07.61-.091zM9.06 12.44c.196-.196.198-.52-.04-.66A2 2 0 0 0 8 11.5a2 2 0 0 0-1.02.28c-.238.14-.236.464-.04.66l.706.706a.5.5 0 0 0 .707 0l.707-.707z"/>
</svg></div>
            </div>
            <div class="mt-4 fs-3" id="visualCC">{displaynum}</div>
            <div><small class="text-secondary">Valid Thru <span id="visualMM">{cardMM}</span> / <span id="visualYY">{cardYY}</span></small></div>
            <div class="mt-3">
              <div class="d-flex justify-content-between align-items-center">
                <div class="text-warning fs-5"><strong id="visualName">{cardname}</strong></div>
              </div>
            </div>
          </div>
          <div class="p-4 shadow bg-white position-relative" id="formWrap">
            <div class="p-5"></div>
            <form action="">
              <div class="form-floating">
                <input type="tel"  class="form-control" id="cardNumber" maxLength={16} value={cardnumber} onChange={(e) => { setCardNumber(e.target.value) }}/>
                <label>Card Number</label>
              </div>
              <div class="form-floating mt-4">
                <input type="text" class="form-control" id="cardName" value={cardname} onChange={(e) => { setCardName(e.target.value) }}/>
                <label>Name On Card</label>
              </div>
              <div class="row mt-2 g-3">
                <div class="col">
                  <div class="form-floating">
                    <input type="tel" class="form-control" id="expiryMonth" maxLength={2} value={cardMM} onChange={(e) => { setCardMM(e.target.value) }}/>
                    <label>Expiry(mm)</label>
                  </div>
                </div>
                <div class="col">
                  <div class="form-floating">
                    <input type="tel" class="form-control" id="expiryYear" maxLength={2} value={cardYY} onChange={(e) => { setCardYY(e.target.value) }}/>
                    <label>Expiry(yy)</label>
                  </div>
                </div>
              </div>
              <div class="row mt-2 g-3">
                <div class="col">
                  <div class="form-floating">
                    <input type="tel" class="form-control" id="CVV" maxLength={3} value={cardCVV} onChange={(e) => { setCardCVV(e.target.value) }}/>
                    <label>CVV</label>
                  </div>
                </div>
                <div class="col">
                  <div class="form-floating">
                    <input type="tel" class="form-control" id="zip" maxLength={6} value={zip} onChange={(e) => { setZip(e.target.value) }}/>
                    <label>Postal / Zip code</label>
                  </div>
                </div>
              </div>
              <div class="mt-3">
                <button class="btn btn-primary w-100" type="submit">Pay Now</button>
              </div>
              <div class="text-center mt-3 text-secondary">
                <small>&#128274; Protected By StayQuest end-to-end encryption service</small>
              </div>
            </form>
          </div>
        </div>
      </div>
    </div>
        </div>
    )
}

export default Payment;