import { useEffect } from "react"
import { useDispatch, useSelector } from "react-redux"
import { update } from "../redux/reducers/registerReducer"

export default function RegistrationSlide(props) {
    const shouldUpdate = useSelector(state => state.register.toUpdate)
    const dispatch = useDispatch()

    useEffect(() => {
        if (props.inputs && shouldUpdate) {
            console.log(document.getElementsByName(props.inputs[0]))
            //  dispatch(disableUpdate())
            dispatch(update({ userData: props.inputs.map(element => ({name: element, value: document.getElementsByName(element).value})) }))
        }
    })

    return (
        <div>
            {props.formSlice}
        </div>)
}