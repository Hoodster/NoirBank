import { Fragment } from "react"
import RegistrationSlide from "../components/RegistrationSlide"
import RegistrationSlider from "../components/RegistrationSlider"

function RegistrationScene() {
    const firstStage = ['usrFN', 'usrLN'], secondStage = ['usrID', 'usrIDNum'], thirdStage=['usrAddrStreet', 'usrAddrBuilding', 'usrAddrApartment', 'usrAddrPostal', 'usrAddrCity', 'usrAddrCountry'], fourthStage=['usrEmail', 'usrPwd']
    return (
        <div>
            <RegistrationSlider slides={[
                {
                    index: 1,
                    title: '1. First and last name',
                    inputs: firstStage,
                    form: <RegistrationSlide inputs={firstStage} formSlice={
                        <Fragment>
                            <input name={firstStage[0]} placeholder='first name'></input>
                            <input name={firstStage[1]} placeholder='last name'></input>
                        </Fragment>
                    }></RegistrationSlide>
                },
                {
                    index: 2,
                    title: '2. Identification',
                    inputs: secondStage,
                    form: <RegistrationSlide formSlice={
                        <Fragment>
                            <input name={secondStage[0]} placeholder='id number'></input>
                            <input name={secondStage[1]} placeholder='id card number'></input>
                        </Fragment>
                    }></RegistrationSlide>
                },
                {
                    index: 3,
                    title: '3. Home address',
                    inputs: thirdStage,
                    form: <RegistrationSlide formSlice={
                        <Fragment>
                            <div>
                                <input name={thirdStage[0]} placeholder='street'></input>
                            </div>
                            <div>
                                <input name={thirdStage[1]} placeholder='building'></input>
                                <input name={thirdStage[2]} placeholder='apartment'></input>
                            </div>
                            <div>
                                <input name={thirdStage[3]} placeholder='postal code'></input>
                                <input name={thirdStage[4]} placeholder='city'></input>
                            </div>
                            <input name={thirdStage[5]} placeholder='country'></input>
                        </Fragment>
                    }></RegistrationSlide>
                },
                {
                    index: 4,
                    title: '4. Credentials',
                    inputs: fourthStage,
                    form: <RegistrationSlide formSlice={
                        <Fragment>
                            <div>
                                <input name={fourthStage[0]} type='email' placeholder='email'></input>
                            </div>
                            <div>
                                <input name={fourthStage[1]} type='password' placeholder='password'></input>
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