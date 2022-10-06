
SELECT
PM.cod_empresa,
PM.alerta,
lpad(PM.sequencia,2,'0') AS sequencia,
PM.num_programa,
PM.data_programa,
PM.cod_equip,
PM.num_ordem,
ORD.ies_situa,
CP.cod_item_cliente,
ORD.cod_item,
trim(MPI.operacao) || ' - ' || trim(OP.den_operac) AS operacao,
ORD.qtd_planej,
ORD.qtd_boas,
CASE
WHEN CAST((ORD.qtd_planej - ORD.qtd_boas) AS INTEGER) < 0 THEN 0 
ELSE CAST((ORD.qtd_planej - ORD.qtd_boas) / MPI.qtd_pecas_ciclo AS DECIMAL(10,3))
END AS horas_necessarias,
CAST(ORD.qtd_boas / ORD.qtd_planej AS DECIMAL(10,3)) AS qtd_percentual,
PM.obs_alerta
FROM tb_programa_maquina_970 PM
LEFT JOIN ordens ORD ON ORD.cod_empresa=PM.cod_empresa AND ORD.num_ordem=PM.num_ordem
LEFT JOIN ciclo_peca_970 CP ON CP.cod_empresa=ORD.cod_empresa AND CP.cod_item=ORD.cod_item
LEFT JOIN man_processo_item MPI ON MPI.empresa=ORD.cod_empresa AND MPI.item=ORD.cod_item
LEFT JOIN operacao OP ON OP.cod_empresa=MPI.empresa AND OP.cod_operac=MPI.operacao
WHERE ORD.ies_situa IN('2','3','4')
AND MPI.operacao NOT IN('042','199')
AND MPI.validade_final IS NULL