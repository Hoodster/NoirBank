import { Fragment } from "react"
import RegistrationSlide from "../components/RegistrationSlide"
import RegistrationSlider from "../components/RegistrationSlider"

function RegistrationScene() {
    return (
        <div>
            <RegistrationSlider slides={[
                {
                    index: 1,
                    title: '1. First and last name',
                    form: <RegistrationSlide formSlice={
                        <Fragment>
                            <input name='userFName' placeholder='first name'></input>
                            <input name='userLName' placeholder='last name'></input>
                        </Fragment>
                    }></RegistrationSlide>
                },
                {
                    index: 2,
                    title: '2. Identification',
                    form: <RegistrationSlide formSlice={
                        <Fragment>
                            <input name='userID' placeholder='id number'></input>
                            <input name='userIDNum' placeholder='id card number'></input>
                        </Fragment>
                    }></RegistrationSlide>
                },
                {
                    index: 3,
                    title: '3. Home address',
                    form: <RegistrationSlide formSlice={
                        <Fragment>
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
                        </Fragment>
                    }></RegistrationSlide>
                },
                {
                    index: 4,
                    title: '4. Credentials',
                    form: <RegistrationSlide formSlice={
                        <Fragment>
                            <div>
                                <input name='userEmail' type='email' placeholder='email'></input>
                            </div>
                            <div>
                                <input name='userPsswd' type='password' placeholder='password'></input>
                            </div>
                        </Fragment>
                    }></RegistrationSlide>
                }
            ]}>

            </RegistrationSlider>
        </div>
    )
}

export default RegistrationScene