import React from 'react'
import { useDispatch } from 'react-redux'
import ModalBase from '../../components/modal/modal-base'

function AddCardModal() {
	const dispatch = useDispatch()

	const primaryActionButton = {
		action: () => prompt('Card added!'),
		text: 'Add new card',
		icon: 'add_card'
	}
	const secondaryActionButton = {
		action: () => dispatch(close()),
		text: 'Cancel'
	}
	return (
		<ModalBase primaryAction={primaryActionButton} secondaryAction={secondaryActionButton} contentPosition='center' title='Add new card'>
			<div>
				shit
			</div>
		</ModalBase>
	)
}

export default AddCardModal