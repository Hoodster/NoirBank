import RegistrationSlide from "../components/RegistrationSlide"
import RegistrationSlider from "../components/RegistrationSlider"

function RegistrationScene() {
    return (
        <div>
            <RegistrationSlider slides={[
                {
                    index: 1,
                    form: <RegistrationSlide number={1}></RegistrationSlide>
                },
                {
                    index: 2,
                    form: <RegistrationSlide number={2}></RegistrationSlide>
                }
        ]}>

            </RegistrationSlider>
            {/* <h1>Welcome to NoirBank</h1>
            <div>
                <h2>Part 1</h2>
                <input name='userFName' placeholder='first name'></input>
                <input name='userLName' placeholder='last name'></input>
            </div>
            <div>
                <h2>Part 2</h2>
                <input name='userEmail' type='email' placeholder='email'></input>
            </div>
            <div>
                <h2>Part3</h2>
                <input name='userID' placeholder='id number'></input>
                <input name='userIDNum' placeholder='id card number'></input>
            </div>
            <div>
                <h2>Part4</h2>
                <div>
                    <input name="userAddrStreet" placeholder='street'></input>
                </div>
                <div>
                    <input name="userAddrBulding" placeholder='building'></input>
                    <input name="userAddrApartment" placeholder='apartment'></input>
                </div>
                <div>
                    <input name="userAddrPostal" placeholder='postal code'></input>
                    <input name="userAddrCity" placeholder='city'></input>
                </div>
                <input name="userAddrCountry" placeholder='country'></input>
            </div>
            <div>
                <h2>Part5</h2>
                <input name='userPsswd' type='password' placeholder='password'></input>
                <input type='submit' value='Create new account'></input>
            </div> */}
        </div>
    )
}

export default RegistrationScene