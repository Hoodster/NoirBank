import { Fragment } from "react"
import RegistrationSlider from "../components/RegistrationSlider"

function RegistrationScene() {
    return (
            <RegistrationSlider slides={[
                {
                    index: 1,
                    title: '1. First and last name',
                    formSlice: 
                        <Fragment>
                            <input name={RegInputs.rFirstName} placeholder='first name'></input>
                            <input name={RegInputs.rLastName} placeholder='last name'></input>
                        </Fragment>          
                },
                {
                    index: 2,
                    title: '2. Identification',
                    formSlice: 
                        <Fragment>
                            <input name={RegInputs.rID} placeholder='id number'></input>
                            <input name={RegInputs.rPersonalID} placeholder='id card number'></input>
                        </Fragment>            
                },
                {
                    index: 3,
                    title: '3. Home address',
                    formSlice: 
                        <Fragment>
                            <div>
                                <input name={RegInputs.rAddressStreet} placeholder='street'></input>
                            </div>
                            <div>
                                <input name={RegInputs.rAddressBuilding} placeholder='building'></input>
                                <input name={RegInputs.rAddressApartment} placeholder='apartment'></input>
                            </div>
                            <div>
                                <input name={RegInputs.rAddressPostalCode} placeholder='postal code'></input>
                                <input name={RegInputs.rAddressCity} placeholder='city'></input>
                            </div>
                            <input name={RegInputs.rAddressCountry} placeholder='country'></input>
                        </Fragment>                
                },
                {
                    index: 4,
                    title: '4. Credentials',
                    formSlice: 
                        <Fragment>
                            <div>
                                <input name={RegInputs.rEmail} type='email' placeholder='email'></input>
                            </div>
                            <div>
                                <input name={RegInputs.rPassword} type='password' placeholder='password'></input>
                            </div>
                        </Fragment>         
                }
            ]}>
            </RegistrationSlider>
    )
}

export default RegistrationScene
export const RegInputs = 
{
    rFirstName: 'usrFN',
    rLastName: 'usrLN',
    rID: 'usrID',
    rPersonalID: 'usrIDNum',
    rAddressStreet: 'usrAddrStreet',
    rAddressBuilding: 'usrAddrBuilding',
    rAddressApartment: 'usrAddrApartment',
    rAddressPostalCode: 'usrAddrPostal',
    rAddressCity: 'usrAddrCity',
    rAddressCountry: 'usrAddrCountry',
    rEmail: 'usrEmail',
    rPassword: 'usrPswd'
}