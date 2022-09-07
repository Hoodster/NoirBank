import { Alert, Snackbar } from '@mui/material'
import React from 'react'
import { useDispatch } from 'react-redux'
import { closeNotification } from '../../redux/reducers/notification-reducer'
import { getIsSimple, getIsOpened, getMessage, getType } from './selectors'

function SnackBar() {
	const dispatch = useDispatch()

	const type = getType()
	const isOpened = getIsOpened()
	const isSimple = getIsSimple()
	const message = getMessage()

	const handleClose = () => {
		dispatch(closeNotification())
	}

	return (
		<Snackbar open={isOpened} autoHideDuration={3000} message={isSimple ? message : ''} onClose={handleClose}>
			{!isSimple
				? < Alert severity={type} onClose={handleClose}>
					{message}
				</Alert>
				: null
			}
		</Snackbar >
	)

}

export default SnackBar