import { useDispatch, useSelector } from "react-redux";
import { nextSlide, prevSlide } from "../redux/reducers/registerReducer";
import { RegInputs } from "../scenes/RegistrationScene";
import axios from 'axios'
import { userAPI } from "../helpers/endpoints";

function RegistrationSlider(props) {
    const register = useSelector(state => state.register)
    const numberOfSlides = register.numberOfSlides
    const currentSlide = register.currentSlide
    const dispatch = useDispatch()

    function nSlide(e) {
        e.preventDefault()
        dispatch(nextSlide())
    }

    function pSlide(e) {
        e.preventDefault()
        dispatch(prevSlide())
    }

    function submitRegistration(e) {
        e.preventDefault()
        const userRegistrationData = {
            firstName: e.target[RegInputs.rFirstName].value,
            lastName: e.target[RegInputs.rLastName].value,
            email: e.target[RegInputs.rEmail].value,
            password: e.target[RegInputs.rPassword].value,
            documentID: e.target[RegInputs.rID].value,
            personalID: e.target[RegInputs.rPersonalID].value,
            address: {
                street: e.target[RegInputs.rAddressStreet].value,
                building: e.target[RegInputs.rAddressBuilding].value,
                apartment: e.target[RegInputs.rAddressApartment].value,
                postalCode: e.target[RegInputs.rAddressPostalCode].value,
                city: e.target[RegInputs.rAddressCity].value,
                country: e.target[RegInputs.rAddressCountry].value
            }
        }
        axios.post(userAPI, userRegistrationData)
        .then((success) => {
        }, (fail) => {
        })
    }

    return (
        <form name='reg-f' onSubmit={(e) => submitRegistration(e)}>
            {
                props.slides.map(slide => {
                    const isCurrentSlide = slide.index === currentSlide || currentSlide === 5
                    return (
                        <div className={currentSlide === 5 ? 'disabled' : null} key={`f-${slide.index}`} style={!isCurrentSlide ? { display: 'none'} : null}>
                            <h3>{slide.title}</h3>
                            {slide.formSlice}
                        </div>
                    )
                })}
            <div>
                {
                    currentSlide === 1
                        ? null
                        : <button onClick={(e) => pSlide(e)}>Previous</button>
                }
                {

                    currentSlide !== numberOfSlides
                        ? <button onClick={(e) => nSlide(e)}>Next</button>
                        : <input type='submit' value='Register this shit'></input>
                }
            </div>
        </form>
    )
}

export default RegistrationSlider