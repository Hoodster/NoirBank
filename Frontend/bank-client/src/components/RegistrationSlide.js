/* eslint-disable react-hooks/exhaustive-deps */
import { useEffect } from "react"
import { useDispatch, useSelector } from "react-redux"
import { update } from "../redux/reducers/registerReducer"

export default function RegistrationSlide(props) {
    const shouldUpdate = useSelector(state => state.register.toUpdate)
    const dispatch = useDispatch()

    useEffect(() => {
        if (shouldUpdate) {
          //  dispatch(disableUpdate())
            dispatch(update({ userData: [] }))
        }
    }, [])

    return <div>{props.number}</div>
}