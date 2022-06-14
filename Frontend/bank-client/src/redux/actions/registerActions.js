import { registerActions } from "../actions"

export const nextSlide = (payload) =>  ({
    type: registerActions.nextSlide,
    payload: payload
})

export const prevSlide = (payload) => ({
    type: registerActions.prevSlide,
    payload: payload
})