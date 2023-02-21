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
			}))
	}
    
	return (
		<div style={{display: 'flex', alignItems: 'center', gap: '5px'}}>
			<input type='number' onChange={(e) => setAmount(e.target.value)} placeholder="amount"/>
			<span>PLN</span>
		</div>
	)
}

export default DepositMoneyForm