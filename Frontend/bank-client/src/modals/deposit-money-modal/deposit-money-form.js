import React from 'react'
import { useDispatch } from 'react-redux'
import { setModalData } from '../../redux/reducers/modal-reducer'
import { getAccountNumber } from './selectors'

function DepositMoneyForm() {
	const dispatch = useDispatch()
	const accountNumber = getAccountNumber()
    
	const setAmount = (amount) => {
		dispatch(setModalData(
			{
				accountNumber,
				amount
			}
		))
	}
    
	return (
		<div>
			<span>PLN</span>
			<input type='number' onChange={(e) => setAmount(e.target.value)} placeholder="amount"/>
		</div>
	)
}

export default DepositMoneyForm