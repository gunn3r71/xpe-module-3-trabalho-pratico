# Trabalho prático mód. 3: Bootcamp: Profissional AWS Cloud Computing - Solução para Desenvolvimento e Ferramentas de Gerenciamento

## <b>Enunciado</b>

<p>A empresa onde você trabalha, sabendo agora que passou pelo Bootcamp Profissional AWS do
IGTI, lhe atribuiu mais responsabilidades em relação a gestão dos ambientes AWS que ela
utiliza. Para o próximo produto da empresa, que te terá como o arquiteto responsável, será
necessário <b>provisionar todas as instâncias EC2 que serão utilizadas e os recursos relacionados
através de código</b>. <b>Você precisará movimentar grandes massas de dados para o S3</b>, onde a
utilização do AWS CLI se faz fundamental e você precisa, então, ter ele instalado, configurado
com credenciais do seu usuário e pronto para ser utilizado na conta desse novo produto.
Essas instâncias EC2 desse novo ambiente, durante as fases de teste, poderão ser desligadas às
19hs e ligadas novamente às 07hs. Além disso, <b>nos fins de semana, as máquinas podem ser
reduzidas a 1 nível em termos de capacidade computacional</b>.</p>

## <b>Tarefas</b>

<ul>
    <li><s>Provisionar EC2 com terraform</s></li>
    <li><s>Para mover uma pasta de arquivos podemos usar o <b>aws s3 mb</b></s></li>
    <li>Criar lambdas para ativar, desativar e trocar tipo instância de servidor</li>
    <li>Criar API Gateway e rotas para cada lambda</li>
    <li>Criar cron no event-bridge para disparar ações de gerenciamento</li>
</ul>