import React from 'react'
import { useDispatch } from 'react-redux'
import ModalBase from '../../components/modal/modal-base'
import { close } from '../../redux/reducers/modal-reducer'

function DefaultModal() {
	const dispatch = useDispatch()

	const primaryAction = {
		text: 'Ok',
		action: () => dispatch(close())
	}

	return (
		<ModalBase title='Error' primaryAction={primaryAction}>
			<span>{'This action isn\'t supported or error has occured.'}</span>
		</ModalBase>
	)
}

export default DefaultModal