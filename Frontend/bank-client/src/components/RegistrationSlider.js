import { useDispatch, useSelector } from "react-redux";
import { nextSlide, prevSlide } from "../redux/reducers/registerReducer";

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
        console.log(e)
    }

    return (
        <form name="reg-f">
            {
                props.slides.map(slide => {
                    if (slide.index === currentSlide)
                        return (<div key={`f-${slide.index}`}>
                            <h3>{slide.title}</h3>
                            {slide.form}
                        </div>)
                    return null
                })
            }
            <div>
                {
                    currentSlide === 1
                        ? null
                        : <button onClick={(e) => pSlide(e)}>Previous</button>
                }
                {

                    currentSlide !== numberOfSlides
                        ? <button onClick={(e) => nSlide(e)}>Next</button>
                        : <input type='submit' onClick={(e) => submitRegistration(e)}></input>
                }
            </div>
        </form>
    )
}

export default RegistrationSlider