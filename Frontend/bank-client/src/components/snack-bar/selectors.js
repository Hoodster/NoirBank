import { useSelector } from 'react-redux'

export const getIsOpened = () => useSelector((state) => state.notification.isOpened)
export const getMessage = () => useSelector((state) => state.notification.message)
export const getType = () => useSelector((state) => state.notification.type)
export const getIsSimple = () => useSelector((state) => state.notification.isSimple)