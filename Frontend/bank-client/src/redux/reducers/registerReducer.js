import { registerActions } from "../actions";

function registerReducer(state = {}, action) {
    let newState = [...state]
    switch(action.name) {
        case registerActions.nextSlide:
            newState.currentSlide = state.currentSlide + 1
            newState.registrationItem = [...state.registrationItem, action.payload.forEach(field => {
                state.registrationItem[field.name] = field.currentValue
            })]
            return newState
        case registerActions.prevSlide:
            newState.currentSlide = state.currentSlide - 1
            newState.registrationItem = [...state.registrationItem, action.payload.forEach(field => {
                state.registrationItem[field.name] = field.currentValue
            })]
            return newState
        default:
        return newState
    }
}

export default registerReducer