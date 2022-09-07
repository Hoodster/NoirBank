import { useSelector } from 'react-redux'

export const isModalOpened = () => useSelector((state) => state.modal.isOpened)