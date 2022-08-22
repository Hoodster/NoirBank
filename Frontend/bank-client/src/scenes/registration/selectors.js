import { useSelector } from 'react-redux'

const getForm = () => useSelector((state) => state.registration.form)
const getCurrentSlide = () => useSelector((state) => state.registration.currentSlide)

export {getForm, getCurrentSlide}