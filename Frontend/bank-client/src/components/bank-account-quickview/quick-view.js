import React from 'react'
import './quick-view.scss'

function BankAccountQuickview() {
	return(
		<div className='nb-account-quickview'>
			<div className='details'>
				<span className='type'>Business</span>
				<span className='name'>Sample account name</span>
				<span className='amount'>4600.87 PLN</span>
			</div>
			<div className='recent'>
				<span className='title'>Recent operation</span>
				<div className='content'>
					<span>11.11.2011</span>
					<span className='content-amount'>-123 PLN</span>
				</div>
			</div>
		</div>
	)
}

export default BankAccountQuickview