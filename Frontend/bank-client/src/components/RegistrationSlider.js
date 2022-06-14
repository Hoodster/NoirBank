import { useDispatch, useSelector } from "react-redux";
import { nextSlide, prevSlide } from "../redux/reducers/registerReducer";

function RegistrationSlider(props) {
    const register = useSelector(state => state.register)
    const numberOfSlides = register.numberOfSlides
    const currentSlide = register.currentSlide
    const dispatch = useDispatch()

    return (
        <div>
            {
                props.slides.map(slide => {
                    if (slide.index === currentSlide)
                        return slide.form
                    return null
                })
            }
            <div>
                {
                    currentSlide === 1
                        ? null
                        : <button onClick={() => dispatch(prevSlide())}>Previous</button>
                }
                {
                    
                    currentSlide !== numberOfSlides
                        ? <button onClick={() => dispatch(nextSlide())}>Next</button>
                        : <button onClick={() => console.log(1)}>Register new account</button>
                }
            </div>
        </div>
    )
}

export default RegistrationSlider